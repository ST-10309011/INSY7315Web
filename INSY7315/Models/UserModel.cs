using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

namespace INSY7315.Models
{
    // The [FirestoreData] attribute tells the Firestore client how to map C# properties to Firestore fields.
    [FirestoreData]
    public class UserModel
    {
        // This property is used internally by the application to hold the Document ID.
        // It is ignored by Firestore when saving/retrieving data fields, but we need it for CRUD operations.
        // It is initialized to an empty string to satisfy CS8618 non-nullable property requirements.
        public string Id { get; set; } = string.Empty;

        // [FirestoreProperty] maps this C# property name to the field name in Firestore.
        [FirestoreProperty("email")]
        [Required]
        public string Email { get; set; } = string.Empty;

        // The Password property (insecure, plain-text in this version)
        [FirestoreProperty("password")]
        public string Password { get; set; } = string.Empty;

        // StudentNumber is required for the Sign Up flow
        [FirestoreProperty("studentNumber")]
        public string StudentNumber { get; set; } = string.Empty;

        // Role (e.g., 'student', 'consultant', 'admin')
        [FirestoreProperty("role")]
        public string Role { get; set; } = string.Empty;

        // Uid is a unique identifier, separate from the Firestore Document ID
        [FirestoreProperty("uid")]
        public string Uid { get; set; } = string.Empty;
    }
}
