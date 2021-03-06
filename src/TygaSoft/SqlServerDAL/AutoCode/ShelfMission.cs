﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.IDAL;
using TygaSoft.Model;
using TygaSoft.DBUtility;

namespace TygaSoft.SqlServerDAL
{
    public partial class ShelfMission : IShelfMission
    {
        #region IShelfMission Member

        public int Insert(ShelfMissionInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into ShelfMission (UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate)
			            values
						(@UserId,@OrderCode,@TotalStayQty,@TotalQty,@Status,@Remark,@Sort,@IsDisable,@LastUpdatedDate)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@UserId",SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@OrderCode",SqlDbType.VarChar,20),
                                        new SqlParameter("@TotalStayQty",SqlDbType.Float),
                                        new SqlParameter("@TotalQty",SqlDbType.Float),
                                        new SqlParameter("@Status",SqlDbType.NVarChar,20),
                                        new SqlParameter("@Remark",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Sort",SqlDbType.Int),
                                        new SqlParameter("@IsDisable",SqlDbType.Bit),
                                        new SqlParameter("@LastUpdatedDate",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.UserId;
            parms[1].Value = model.OrderCode;
            parms[2].Value = model.TotalStayQty;
            parms[3].Value = model.TotalQty;
            parms[4].Value = model.Status;
            parms[5].Value = model.Remark;
            parms[6].Value = model.Sort;
            parms[7].Value = model.IsDisable;
            parms[8].Value = model.LastUpdatedDate;

            return SqlHelper.ExecuteNonQuery(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int InsertByOutput(ShelfMissionInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into ShelfMission (Id,UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate)
			            values
						(@Id,@UserId,@OrderCode,@TotalStayQty,@TotalQty,@Status,@Remark,@Sort,@IsDisable,@LastUpdatedDate)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@Id",SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@UserId",SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@OrderCode",SqlDbType.VarChar,20),
                                        new SqlParameter("@TotalStayQty",SqlDbType.Float),
                                        new SqlParameter("@TotalQty",SqlDbType.Float),
                                        new SqlParameter("@Status",SqlDbType.NVarChar,20),
                                        new SqlParameter("@Remark",SqlDbType.NVarChar,100),
                                        new SqlParameter("@Sort",SqlDbType.Int),
                                        new SqlParameter("@IsDisable",SqlDbType.Bit),
                                        new SqlParameter("@LastUpdatedDate",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.Id;
            parms[1].Value = model.UserId;
            parms[2].Value = model.OrderCode;
            parms[3].Value = model.TotalStayQty;
            parms[4].Value = model.TotalQty;
            parms[5].Value = model.Status;
            parms[6].Value = model.Remark;
            parms[7].Value = model.Sort;
            parms[8].Value = model.IsDisable;
            parms[9].Value = model.LastUpdatedDate;

            return SqlHelper.ExecuteNonQuery(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(ShelfMissionInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update ShelfMission set UserId = @UserId,OrderCode = @OrderCode,TotalStayQty = @TotalStayQty,TotalQty = @TotalQty,Status = @Status,Remark = @Remark,Sort = @Sort,IsDisable = @IsDisable,LastUpdatedDate = @LastUpdatedDate 
			            where Id = @Id
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@Id",SqlDbType.UniqueIdentifier),
                                    new SqlParameter("@UserId",SqlDbType.UniqueIdentifier),
                                    new SqlParameter("@OrderCode",SqlDbType.VarChar,20),
                                    new SqlParameter("@TotalStayQty",SqlDbType.Float),
                                    new SqlParameter("@TotalQty",SqlDbType.Float),
                                    new SqlParameter("@Status",SqlDbType.NVarChar,20),
                                    new SqlParameter("@Remark",SqlDbType.NVarChar,100),
                                    new SqlParameter("@Sort",SqlDbType.Int),
                                    new SqlParameter("@IsDisable",SqlDbType.Bit),
                                    new SqlParameter("@LastUpdatedDate",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.Id;
            parms[1].Value = model.UserId;
            parms[2].Value = model.OrderCode;
            parms[3].Value = model.TotalStayQty;
            parms[4].Value = model.TotalQty;
            parms[5].Value = model.Status;
            parms[6].Value = model.Remark;
            parms[7].Value = model.Sort;
            parms[8].Value = model.IsDisable;
            parms[9].Value = model.LastUpdatedDate;

            return SqlHelper.ExecuteNonQuery(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(Guid id)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from ShelfMission where Id = @Id ");
            SqlParameter[] parms = {
                                     new SqlParameter("@Id",SqlDbType.UniqueIdentifier)
                                   };
            parms[0].Value = id;

            return SqlHelper.ExecuteNonQuery(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public bool DeleteBatch(IList<object> list)
        {
            StringBuilder sb = new StringBuilder(500);
            ParamsHelper parms = new ParamsHelper();
            int n = 0;
            foreach (string item in list)
            {
                n++;
                sb.Append(@"delete from ShelfMission where Id = @Id" + n + " ;");
                SqlParameter parm = new SqlParameter("@Id" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public ShelfMissionInfo GetModel(Guid id)
        {
            ShelfMissionInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 Id,UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate 
			            from ShelfMission
						where Id = @Id ");
            SqlParameter[] parms = {
                                     new SqlParameter("@Id",SqlDbType.UniqueIdentifier)
                                   };
            parms[0].Value = id;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new ShelfMissionInfo();
                        model.Id = reader.GetGuid(0);
                        model.UserId = reader.GetGuid(1);
                        model.OrderCode = reader.GetString(2);
                        model.TotalStayQty = reader.GetDouble(3);
                        model.TotalQty = reader.GetDouble(4);
                        model.Status = reader.GetString(5);
                        model.Remark = reader.GetString(6);
                        model.Sort = reader.GetInt32(7);
                        model.IsDisable = reader.GetBoolean(8);
                        model.LastUpdatedDate = reader.GetDateTime(9);
                    }
                }
            }

            return model;
        }

        public IList<ShelfMissionInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from ShelfMission ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<ShelfMissionInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by Sort,LastUpdatedDate desc) as RowNumber,
			          Id,UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate
					  from ShelfMission ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<ShelfMissionInfo> list = new List<ShelfMissionInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShelfMissionInfo model = new ShelfMissionInfo();
                        model.Id = reader.GetGuid(1);
                        model.UserId = reader.GetGuid(2);
                        model.OrderCode = reader.GetString(3);
                        model.TotalStayQty = reader.GetDouble(4);
                        model.TotalQty = reader.GetDouble(5);
                        model.Status = reader.GetString(6);
                        model.Remark = reader.GetString(7);
                        model.Sort = reader.GetInt32(8);
                        model.IsDisable = reader.GetBoolean(9);
                        model.LastUpdatedDate = reader.GetDateTime(10);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<ShelfMissionInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by Sort,LastUpdatedDate desc) as RowNumber,
			           Id,UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate
					   from ShelfMission ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<ShelfMissionInfo> list = new List<ShelfMissionInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShelfMissionInfo model = new ShelfMissionInfo();
                        model.Id = reader.GetGuid(1);
                        model.UserId = reader.GetGuid(2);
                        model.OrderCode = reader.GetString(3);
                        model.TotalStayQty = reader.GetDouble(4);
                        model.TotalQty = reader.GetDouble(5);
                        model.Status = reader.GetString(6);
                        model.Remark = reader.GetString(7);
                        model.Sort = reader.GetInt32(8);
                        model.IsDisable = reader.GetBoolean(9);
                        model.LastUpdatedDate = reader.GetDateTime(10);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<ShelfMissionInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select Id,UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate
                        from ShelfMission ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by Sort,Status,LastUpdatedDate desc ");

            IList<ShelfMissionInfo> list = new List<ShelfMissionInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShelfMissionInfo model = new ShelfMissionInfo();
                        model.Id = reader.GetGuid(0);
                        model.UserId = reader.GetGuid(1);
                        model.OrderCode = reader.GetString(2);
                        model.TotalStayQty = reader.GetDouble(3);
                        model.TotalQty = reader.GetDouble(4);
                        model.Status = reader.GetString(5);
                        model.Remark = reader.GetString(6);
                        model.Sort = reader.GetInt32(7);
                        model.IsDisable = reader.GetBoolean(8);
                        model.LastUpdatedDate = reader.GetDateTime(9);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<ShelfMissionInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select Id,UserId,OrderCode,TotalStayQty,TotalQty,Status,Remark,Sort,IsDisable,LastUpdatedDate 
			            from ShelfMission
					    order by Sort,LastUpdatedDate desc ");

            IList<ShelfMissionInfo> list = new List<ShelfMissionInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.WmsDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShelfMissionInfo model = new ShelfMissionInfo();
                        model.Id = reader.GetGuid(0);
                        model.UserId = reader.GetGuid(1);
                        model.OrderCode = reader.GetString(2);
                        model.TotalStayQty = reader.GetDouble(3);
                        model.TotalQty = reader.GetDouble(4);
                        model.Status = reader.GetString(5);
                        model.Remark = reader.GetString(6);
                        model.Sort = reader.GetInt32(7);
                        model.IsDisable = reader.GetBoolean(8);
                        model.LastUpdatedDate = reader.GetDateTime(9);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
