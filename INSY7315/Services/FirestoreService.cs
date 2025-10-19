using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using INSY7315.Models;
// We need this using statement for the correct client builder and client
using Google.Cloud.Firestore.V1;
// We need System.Reflection for the new path approach
using System.Reflection;

namespace INSY7315.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _db;

        // We use IWebHostEnvironment to correctly locate the file path in the project
        public FirestoreService(IWebHostEnvironment env)
        {
            // 1. Define the filename
            // *** FIX APPLIED HERE: Changed 'cc99' to 'cc97' to match the file system ***
            string credentialsFileName = "aftergrad-db-firebase-adminsdk-fbsvc-cc9757a6da.json";

            // The most robust way to get the executing assembly's directory (the bin/Debug/net8.0 folder)
            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppDomain.CurrentDomain.BaseDirectory;

            // Path C: The bin/Debug/net8.0 directory (most likely location for copied files)
            string pathC = Path.Combine(baseDir, credentialsFileName);

            // Path A: Check the Content Root Path (where the project source files are, often the development path)
            string pathA = Path.Combine(env.ContentRootPath, credentialsFileName);

            // 2. Choose the correct path (prioritizing the base execution directory)
            string credentialsPath = "";

            if (File.Exists(pathC)) // Check the base directory first (where 'Copy always' puts it)
            {
                credentialsPath = pathC;
            }
            else if (File.Exists(pathA)) // Check the project root (where the source file is located)
            {
                credentialsPath = pathA;
            }

            // !!! IMPORTANT: Replace "aftergrad-db" with your actual Firebase Project ID.
            string projectId = "aftergrad-db";

            // --- Explicitly Load and Create Credentials ---
            if (!string.IsNullOrEmpty(credentialsPath))
            {
                // *** FIX: Set GOOGLE_APPLICATION_CREDENTIALS for robust authentication ***
                // This tells the Google Cloud SDK exactly where the file is, 
                // preventing the SDK from having to search for it itself.
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);

                // Now we can use the simpler Create overload, relying on the environment variable
                _db = FirestoreDb.Create(projectId);
            }
            else
            {
                // If the file is still not found, throw a detailed exception.
                throw new FileNotFoundException(
                    "Firebase credentials file not found. " +
                    $"Attempted locations: \n1. {pathC} (BaseDirectory)\n2. {pathA} (ContentRootPath)\n" +
                    "Ensure the file is in the project root and its 'Copy to Output Directory' property is set to 'Copy always'.");
            }
        }

        // -----------------------------------------------------------------
        // USER AUTHENTICATION METHODS 
        // -----------------------------------------------------------------

        /// <summary>
        /// Attempts to find a user document based on email.
        /// </summary>
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            // Query the 'users' collection for the matching email
            Query query = _db.Collection("users").WhereEqualTo("email", email);

            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            if (snapshot.Documents.Any())
            {
                var doc = snapshot.Documents.First();
                var user = doc.ConvertTo<UserModel>();
                user.Id = doc.Id; // Set the C# Id property to the Firestore Document ID
                return user;
            }
            return null;
        }

        /// <summary>
        /// Registers a new user document in the 'users' collection.
        /// </summary>
        public async Task<string> RegisterUserAsync(UserModel user)
        {
            CollectionReference usersRef = _db.Collection("users");

            // Firestore saves the C# model data using the [FirestoreProperty] mappings
            var documentRef = await usersRef.AddAsync(user);

            return documentRef.Id;
        }
    }
}
