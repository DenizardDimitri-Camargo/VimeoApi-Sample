using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VimeoSample.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        //public string professor { get; set; }
        public ApplicationUser Professor { get; set; }
        public int ProfessorId { get; set; }
        public ICollection<LocalUploadRequest> Videos { get; set; } = new List<LocalUploadRequest>();

        public List<LocalUploadRequest> GetVideos(string userId)
        {
            return Videos.Where(ur => ur.ApplicationUser.Id.Equals(userId)).ToList();
        }

    }
}
