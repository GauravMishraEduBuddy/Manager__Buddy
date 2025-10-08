namespace EduBuddyApp.Services;

public static class BlobStorageService
{
    private const string AccountName = "edubuddydata";

    public static string GetStuPhotoUrl(int studentId, string containerName)
    {
        string baseUrl = $"https://{AccountName}.blob.core.windows.net";
        return $"{baseUrl}/{containerName}/student-pics/{studentId}.jpg";
    }
}
