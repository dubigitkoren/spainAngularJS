using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebApplication2
{
    public class DetailsController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            string json = "";
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.Connection = sqlConn;
                        da.SelectCommand.CommandText = "GetDetailsRecords";
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(table);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }          
            
            json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            string json = "";
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.Connection = sqlConn;
                        da.SelectCommand.CommandText = "GetDetailsRecordById";
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = id;
                        da.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        public class details {
            public string mCurrentEditId { get; set; }
            public DateTime mDateofAuto { get; set; }
            public string mTribunal { get; set; }
            public string mselTypeofAuto { get; set; }
            public string mLocationofAuto { get; set; }
            public string mtxtName { get; set; }
            public string mAliases { get; set; }
            public string mselGender { get; set; }            
            public string mselPersonalStatus { get; set; }
            public string mOccupation { get; set; }
            public string mFamilyTies { get; set; }
            public string mLocationOfBirth { get; set; }
            public string mResidence { get; set; }
            public string mTypeOfCrime { get; set; }
            public string mSentence { get; set; }
            public string mAdditionalInformation { get; set; }
            public string mAge { get; set; }
            public string mGenealogicalOrigin { get; set; }
            public string mSurname { get; set; }
            public string mBishopricOfBirth { get; set; }
            public string mBishopricOfResidence { get; set; }
            public string mPunishment { get; set; }
        }


        // POST api/<controller>
        public void Post([FromBody]details value)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    SqlCommand cmd;
                    if (value.mCurrentEditId == null)
                        cmd = new SqlCommand("InsertToDetails", sqlConn);
                    else
                    {
                        cmd = new SqlCommand("UpdateDetails", sqlConn);
                        cmd.Parameters.Add("@pCurrentEditId", SqlDbType.Int).Value = int.Parse(value.mCurrentEditId);
                        value.mDateofAuto = value.mDateofAuto.AddDays(-1);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@pDateOfAuto", SqlDbType.Date).Value = value.mDateofAuto.AddDays(1) ;
                    cmd.Parameters.Add("@pTribunal", SqlDbType.NVarChar).Value = value.mTribunal ?? "";
                    cmd.Parameters.Add("@pTypeOfAuto", SqlDbType.NVarChar).Value = value.mselTypeofAuto ?? "";
                    cmd.Parameters.Add("@pLocationofAuto", SqlDbType.NVarChar).Value = value.mLocationofAuto ?? "";
                    cmd.Parameters.Add("@pName", SqlDbType.NVarChar).Value = value.mtxtName ?? "";
                    cmd.Parameters.Add("@pAliases", SqlDbType.NVarChar).Value = value.mAliases ?? "";
                    cmd.Parameters.Add("@pGender", SqlDbType.NVarChar).Value = value.mselGender ?? "";                    
                    cmd.Parameters.Add("@pPersonalStatus", SqlDbType.NVarChar).Value = value.mselPersonalStatus ?? "";
                    cmd.Parameters.Add("@pOccupation", SqlDbType.NVarChar).Value = value.mOccupation ?? "";
                    cmd.Parameters.Add("@pFamilyTies", SqlDbType.NVarChar).Value = value.mFamilyTies ?? "";
                    cmd.Parameters.Add("@pLocationOfBirth", SqlDbType.NVarChar).Value = value.mLocationOfBirth ?? "";
                    cmd.Parameters.Add("@pResidence", SqlDbType.NVarChar).Value = value.mResidence ?? "";
                    cmd.Parameters.Add("@pTypeOfCrime", SqlDbType.NVarChar).Value = value.mTypeOfCrime ?? "";
                    cmd.Parameters.Add("@pSentence", SqlDbType.NVarChar).Value = value.mSentence ?? "";
                    cmd.Parameters.Add("@pAdditionalInformation", SqlDbType.NVarChar).Value = value.mAdditionalInformation ?? "";

                    cmd.Parameters.Add("@pAge", SqlDbType.NVarChar).Value = value.mAge ;
                    cmd.Parameters.Add("@pGenealogicalOrigin", SqlDbType.NVarChar).Value = value.mGenealogicalOrigin ?? "";
                    cmd.Parameters.Add("@pSurname", SqlDbType.NVarChar).Value = value.mSurname ?? "";
                    cmd.Parameters.Add("@pBishopricOfBirth", SqlDbType.NVarChar).Value = value.mBishopricOfBirth ?? "";
                    cmd.Parameters.Add("@pBishopricOfResidence", SqlDbType.NVarChar).Value = value.mBishopricOfResidence ?? "";
                    cmd.Parameters.Add("@pPunishment", SqlDbType.NVarChar).Value = value.mPunishment ?? "";

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    SqlCommand cmd;
                   
                    cmd = new SqlCommand("deleteDetailsRecord", sqlConn);
                  
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@pCurrentEditId", SqlDbType.Int).Value = id;
                                       
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}