using DataTableToList.Configarations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataTableToList
{
    public class ConversionProcess
    {
        public List<PersonalInfo> UsingLoop()
        {
            DataTable dt = DataPreparations.GetDataTableData();
            List<PersonalInfo> listPersonalInfo = new List<PersonalInfo>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PersonalInfo _PersonalInfo = new PersonalInfo();

                _PersonalInfo.PersonalInfoID = Convert.ToInt64(dt.Rows[i]["PersonalInfoID"]);
                _PersonalInfo.FirstName = dt.Rows[i]["FirstName"].ToString().Trim();
                _PersonalInfo.LastName = dt.Rows[i]["LastName"].ToString().Trim();
                _PersonalInfo.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
                _PersonalInfo.City = dt.Rows[i]["City"].ToString().Trim();

                _PersonalInfo.Country = dt.Rows[i]["Country"].ToString().Trim();
                _PersonalInfo.MobileNo = dt.Rows[i]["MobileNo"].ToString().Trim();
                _PersonalInfo.NID = dt.Rows[i]["NID"].ToString().Trim();
                _PersonalInfo.Email = dt.Rows[i]["Email"].ToString().Trim();
                _PersonalInfo.Status = Convert.ToInt16(dt.Rows[i]["Status"]);

                listPersonalInfo.Add(_PersonalInfo);
            }

            return listPersonalInfo;
        }


        public List<PersonalInfo> UsingLINQ()
        {
            DataTable dt = DataPreparations.GetDataTableData();
            List<PersonalInfo> listPersonalInfo = new List<PersonalInfo>();


            listPersonalInfo = (from DataRow dr in dt.Rows
                                select new PersonalInfo()
                                {
                                    PersonalInfoID = Convert.ToInt64(dr["PersonalInfoID"]),
                                    FirstName = dr["FirstName"].ToString(),
                                    LastName = dr["LastName"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString()),
                                    City = dr["City"].ToString(),

                                    Country = dr["Country"].ToString(),
                                    MobileNo = dr["MobileNo"].ToString(),
                                    NID = dr["NID"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Status = Convert.ToInt16(dr["Status"])

                                }).ToList();

            return listPersonalInfo;
        }


        public List<PersonalInfo> UsingReader()
        {
            SqlConnection oMSSQLConnection = MSSQLConn.GetMSSQLConn();
            if (oMSSQLConnection.State != ConnectionState.Open) oMSSQLConnection.Open();
            SqlDataReader myReader = null;

            using (SqlCommand myCommand = new SqlCommand("select * from PersonalInfo", oMSSQLConnection))
            {
                myReader = myCommand.ExecuteReader();
            }

            List<PersonalInfo> listPersonalInfo = new List<PersonalInfo>();
            while (myReader.Read())
            {
                listPersonalInfo.Add(new PersonalInfo
                {
                    PersonalInfoID = myReader["PersonalInfoID"] == DBNull.Value ? 0 : Convert.ToInt64(myReader["PersonalInfoID"]),
                    FirstName = myReader["FirstName"] == DBNull.Value ? null : myReader["FirstName"].ToString(),
                    LastName = myReader["LastName"] == DBNull.Value ? null : myReader["LastName"].ToString(),
                    DateOfBirth = myReader["DateOfBirth"] == DBNull.Value ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(myReader["DateOfBirth"]),

                    City = myReader["City"] == DBNull.Value ? null : myReader["City"].ToString(),
                    Country = myReader["Country"] == DBNull.Value ? null : myReader["Country"].ToString(),
                    MobileNo = myReader["MobileNo"] == DBNull.Value ? null : myReader["MobileNo"].ToString(),
                    NID = myReader["NID"] == DBNull.Value ? null : myReader["NID"].ToString(),

                    Email = myReader["Email"] == DBNull.Value ? null : myReader["Email"].ToString(),
                    Status = myReader["Status"] == DBNull.Value ? 0 : Convert.ToInt16(myReader["Status"])
                });
            }

            oMSSQLConnection.Close();

            return listPersonalInfo;
        }





    }
}
