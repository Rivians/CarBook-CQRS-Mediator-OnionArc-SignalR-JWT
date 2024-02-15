using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands
{
    public class RemoveAboutCommand
    {
        // id'e göre silme işlemi yapacagımız icin sadece id'i kullanıyoruz
        public int Id { get; set; }
        public RemoveAboutCommand(int id)
        {
            Id = id;
        }
    }
}
