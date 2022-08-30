using AutoMapper;
using Blog.Core.Models;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Blog.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(IGenericRepository<Comment> repository, IUnitOfWork unitOfWork, ICommentRepository commentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
    }
}
