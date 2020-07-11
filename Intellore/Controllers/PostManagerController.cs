using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
using AutoMapper;
using Intellore.ViewModels;
using tg = Models.Tag;
using tgView = Intellore.ViewModels.Tag; 


namespace Intellore.Controllers
{
    public class PostManagerController : ApiController
    {
        [HttpGet]
        [Route("PostManager/Get")]
        public async Task<HttpResponseMessage> Get(int postId)
        {
            DAL objData = new DAL();

            PostDetailsModel objPostDetails = new PostDetailsModel();
            PostDetailsViewModel objPostViewModel = new PostDetailsViewModel();

            try
            {
                objPostDetails = objData.GetPostDetailsById(postId);

                //Mapper.CreateMap<PostDetailsModel, PostDetailsViewModel>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PostDetailsModel, PostDetailsViewModel>();
                    cfg.CreateMap<tg, tgView>();                    
                });

                IMapper mapper = config.CreateMapper();
                var source = new PostDetailsModel();
                var dest = mapper.Map<PostDetailsModel, PostDetailsViewModel>(objPostDetails);

                //PostDetailsViewModel objPostViewModel = Mapper.Map<PostDetailsModel, PostDetailsViewModel>(objPostDetails);

                return await Task.Run(() => Request.CreateResponse(HttpStatusCode.OK, dest));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
