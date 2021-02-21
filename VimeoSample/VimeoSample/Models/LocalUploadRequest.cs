//using VimeoDotNet.Net;

namespace VimeoSample.Models
{
    public class LocalUploadRequest /*: UploadRequest*/ //video
    {
        public LocalUploadRequest()
        {
        }
        public LocalUploadRequest(int chunkSize, long bytesWritten, bool isVerifiedComplete, string clipUri, long fileLength, long? clipId, ApplicationUser applicationUser)
        {
            ChunkSize = chunkSize;
            BytesWritten = bytesWritten;
            IsVerifiedComplete = isVerifiedComplete;
            ClipUri = clipUri;
            FileLength = fileLength;
            ClipId = clipId;
            ApplicationUser = applicationUser;
        }

        public int Id { get; set; }


        //public UploadTicket Ticket { get; set; }
        public int ChunkSize { get; set; }
        public long BytesWritten { get; set; }
        public bool IsVerifiedComplete { get; set; }
        public string ClipUri { get; set; }
        //public IBinaryContent File { get; set; }
        public long FileLength { get; set; }
        public long? ClipId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        //public string UsersId(string userId)
        //{
        //    var result = ApplicationUser.Id.w;
        //    return result;
        //}
    }
}