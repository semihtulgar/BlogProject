using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        // İlgili comment için özel operasyonlar
    }
}
