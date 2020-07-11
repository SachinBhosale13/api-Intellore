using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Intellore.Controllers
{
    public class TaskManagerController : ApiController
    {
        [HttpPost]
        [Route("TaskManager/UntagPost")]
        public async Task<HttpResponseMessage> UntagPost(int postId, int tagId)
        {
            DAL objData = new DAL();
            UntagResponse response = new UntagResponse();
            bool isUntagged = false;

            try
            {
                if (postId == 0)
                {
                    response.Message = "postId should be positive integer number.";
                    throw new ArgumentNullException(string.Format("postId"));
                }
                else if (tagId == 0)
                {
                    response.Message = "tagId should be positive integer number.";
                    throw new ArgumentNullException(string.Format("tagId"));
                }

                if (objData.IsPostExist(postId))
                {
                    if (objData.IsTagOfPost(postId, tagId))
                    {
                        isUntagged = objData.UntagPost(postId, tagId);
                        if (isUntagged)
                        {
                            response.Untagged = true;
                            response.Message = "Post is untagged successfully.";
                            return await Task.Run(() => Request.CreateResponse(HttpStatusCode.OK, response));
                        }
                    }
                    else
                    {
                        response.Message = "Tag does not belong to post";
                        throw new ArgumentOutOfRangeException(string.Format("tagId"));
                    }
                }
                else
                {
                    response.Message = "Post does not exist.";
                    throw new ArgumentOutOfRangeException(string.Format("postId"));
                }

                response.Untagged = false;
                response.Message = "Something went wrong.";
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            catch (ArgumentException ex) 
            {
                response.Untagged = false;
                response.exception = ex.GetType().ToString() + " ~" + ex.Message.ToString();
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                response.Untagged = false;
                response.exception = ex.GetType().ToString() + " ~" + ex.Message.ToString();
                response.Message = "Something Went wrong.";
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
