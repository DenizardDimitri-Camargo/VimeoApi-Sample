using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using VimeoDotNet.Models;

namespace VimeoSample.Models
{
    public class LocalVideo /*: Video*/
    {
        public LocalVideo()
        {

        }

        public int Id { get; set; }

        //
        // Summary:
        //     High definition video secure link
        public string HighDefinitionVideoSecureLink { get; }
        //
        // Summary:
        //     High definition video link
        public string HighDefinitionVideoLink { get; }
        //
        // Summary:
        //     Standard video secure link
        public string StandardVideoSecureLink { get; }
        //
        // Summary:
        //     Standard video link
        public string StandardVideoLink { get; }
        //
        // Summary:
        //     Mobile video secure link
        public string MobileVideoSecureLink { get; }
        //
        // Summary:
        //     Mobile video link
        public string MobileVideoLink { get; }
        //
        // Summary:
        //     Video status
        //public VideoStatusEnum VideoStatus { get; set; }
        //
        // Summary:
        //     Metadata
        //[JsonProperty(PropertyName = "metadata")]
        //public VideoMetadata Metadata { get; set; }
        ////
        //// Summary:
        ////     Stats
        //[JsonProperty(PropertyName = "stats")]
        //public VideoStats Stats { get; set; }
        ////
        //// Summary:
        ////     Tags
        //[JsonProperty(PropertyName = "tags")]
        //public List<Tag> Tags { get; set; }
        ////
        //// Summary:
        ////     Download
        //[JsonProperty(PropertyName = "download")]
        //public List<Download> Download { get; set; }
        ////
        //// Summary:
        ////     Files
        //[JsonProperty(PropertyName = "files")]
        //public List<File> Files { get; set; }
        ////
        //// Summary:
        ////     Pictures
        //[JsonProperty(PropertyName = "pictures")]
        //public Pictures Pictures { get; set; }
        //
        // Summary:
        //     Streaming video link
        public string StreamingVideoLink { get; }
        //
        // Summary:
        //     Privacy
        //[JsonProperty(PropertyName = "privacy")]
        //public Privacy Privacy { get; set; }
        //
        // Summary:
        //     Created time
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }
        //
        // Summary:
        //     Height
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        //
        // Summary:
        //     Width
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        //
        // Summary:
        //     Duration
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }
        //
        // Summary:
        //     Embed presets
        //[JsonProperty(PropertyName = "embed_presets")]
        //public EmbedPresets EmbedPresets { get; set; }
        //
        // Summary:
        //     Status
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        //
        // Summary:
        //     Review link
        [JsonProperty(PropertyName = "review_link")]
        public string ReviewLink { get; set; }
        //
        // Summary:
        //     Link
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        //
        // Summary:
        //     Description
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        //
        // Summary:
        //     Name
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        //
        // Summary:
        //     User
        //[JsonProperty(PropertyName = "user")]
        //public User User { get; set; }
        //
        // Summary:
        //     URI
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
        //
        // Summary:
        //     Id
        //public long? Id { get; }
        //
        // Summary:
        //     Modified time
        [JsonProperty(PropertyName = "modified_time")]
        public DateTime ModifiedTime { get; set; }
        //
        // Summary:
        //     Streaming video secure link
        public string StreamingVideoSecureLink { get; }
    }
}
