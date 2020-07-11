using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Models;

namespace DataAccessLayer
{
    public class DAL
    {
        string connString = ConfigurationManager.ConnectionStrings["IntelloreConn"].ToString();


        #region Untag Post methods
        public bool UntagPost(int postId, int tagId) 
        {
            SqlConnection conn = new SqlConnection(connString);
            bool isUntagged = false;
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("UntagPost", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@post_id", postId);
                cmd.Parameters.AddWithValue("@tag_id", tagId);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    isUntagged = true;
                }

                return isUntagged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsPostExist(int postId) 
        {
            SqlConnection conn = new SqlConnection(connString);
            bool isExist = false;
            int count = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("IsPostExist", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@post_id", postId);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0) 
                {
                    isExist = true;
                }

                return isExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsTagOfPost(int postId, int tagId) 
        {
            SqlConnection conn = new SqlConnection(connString);
            bool isExist = false;
            int count = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("IsTagOfPost", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@post_id", postId);
                cmd.Parameters.AddWithValue("@tag_id", tagId);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    isExist = true;
                }

                return isExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region get post details

        public PostDetailsModel GetPostDetailsById(int postId)
        {
            PostDetailsModel objPostDetails = new PostDetailsModel();
            try
            {
                objPostDetails = GetPostDetails(postId);

                objPostDetails.tags = new List<Tag>();

                objPostDetails.tags = GetTagsOfPost(postId);

                return objPostDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PostDetailsModel GetPostDetails(int postId)
        {
            SqlConnection conn = new SqlConnection(connString);
            PostDetailsModel objPostDetails = new PostDetailsModel();

            try
            {
                SqlCommand cmd = new SqlCommand("GetPostById", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@post_id", postId);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        objPostDetails.id = Convert.ToInt32(rdr["id"]);
                        objPostDetails.title = Convert.ToString(rdr["title"]);
                        objPostDetails.content = Convert.ToString(rdr["content"]);
                        objPostDetails.author_name = Convert.ToString(rdr["author_name"]);
                        objPostDetails.post_date = Convert.ToString(rdr["post_date"]);
                    }
                }

                return objPostDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tag> GetTagsOfPost(int postId)
        {
            SqlConnection conn = new SqlConnection(connString);
            List<Tag> lstTags = new List<Tag>();

            try
            {
                SqlCommand cmd = new SqlCommand("GetTagsOfPost", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@post_id", postId);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Tag tag = new Tag();
                        tag.tag_id = Convert.ToInt32(rdr["tag_id"]);
                        tag.tag_name = Convert.ToString(rdr["tag_name"]);

                        lstTags.Add(tag);
                    }
                }

                return lstTags;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}

