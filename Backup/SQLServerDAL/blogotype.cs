///
//?????,?????CodeSmith??
//???:??
//????:2010?1?24?
///

using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

using Blogo.Model;
using Blogo.DBUtility;
using Blogo.IDAL;


namespace Blogo.SQLServerDAL
{
	///
	//Blogotype
	///
	public class Blogotype:IBlogotype
	{
		public  BlogotypeEntity SelectBlogotypeByID(int t_blogtype_id)
		{
			BlogotypeEntity t_Blogotype=new BlogotypeEntity();
			SqlDataReader sdr =null;
			using(sdr=SqlDBHelp.GetReader("select * from Blogotypes where blogtype_id="+t_blogtype_id))
			{
				if(sdr.Read())
				{
					t_Blogotype.Blogtype_id=(int)sdr.GetValue(0);
					t_Blogotype.Name=(string)sdr.GetValue(1);
					t_Blogotype.Author_id=(int)sdr.GetValue(2);
					
				}
				
			}
			sdr.Close();
			
			return t_Blogotype;
		}
		
		public IList<BlogotypeEntity> GetAllBlogotype()
		{
			IList<BlogotypeEntity> t_Blogotypes=new List<BlogotypeEntity>();
			SqlDataReader sdr=null;
			using(sdr=SqlDBHelp.GetReader("select * from Blogotypes"))
			{
				while(sdr.Read())
				{
					BlogotypeEntity t_Blogotype=new BlogotypeEntity();
					t_Blogotype.Blogtype_id=(int)sdr.GetValue(0);					
					t_Blogotype.Name=(string)sdr.GetValue(1);					
					t_Blogotype.Author_id=(int)sdr.GetValue(2);					
					t_Blogotypes.Add(t_Blogotype);
				}
				sdr.Close();
			}
			
			return t_Blogotypes;
		}
		
		
		public IList<BlogotypeEntity> GetAllBlogotypeByauthor_id(int t_author_id)
		{
			IList<BlogotypeEntity> t_Blogotypes=new List<BlogotypeEntity>();
			SqlDataReader sdr=null;
			using(sdr=SqlDBHelp.GetReader("select * from Blogotypes where author_id="+t_author_id))
			{
				while(sdr.Read())
				{
					BlogotypeEntity t_Blogotype=new BlogotypeEntity();
					t_Blogotype.Blogtype_id=(int)sdr.GetValue(0);
					t_Blogotype.Name=(string)sdr.GetValue(1);
					t_Blogotype.Author_id=(int)sdr.GetValue(2);
					t_Blogotypes.Add(t_Blogotype);
				}
				sdr.Close();
			}
			
			return t_Blogotypes;
		}
	
		public  int InsertBlogotype(BlogotypeEntity t_Blogotype)
		{			
			SqlParameter[] p=new SqlParameter[]{
				new SqlParameter("@Blogtype_id",t_Blogotype.Blogtype_id),					
				new SqlParameter("@Name",t_Blogotype.Name),					
				new SqlParameter("@Author_id",t_Blogotype.Author_id)				
				
			};
			
			int i=SqlDBHelp.GetExecute("insert into Blogotypes values(@Blogtype_id,@Name,@Author_id)",p);
			return i;				
		}
		
		public  int UpdateBlogotype(BlogotypeEntity t_Blogotype)
		{
			SqlParameter[] p=new SqlParameter[]{
				new SqlParameter("@Blogtype_id",t_Blogotype.Blogtype_id),					
				new SqlParameter("@Name",t_Blogotype.Name),					
				new SqlParameter("@Author_id",t_Blogotype.Author_id)				
				
			};
			
			int i=SqlDBHelp.GetExecute("update Blogotypes set name=@Name,author_id=@Author_id where blogtype_id=@Blogtype_id",p);
			return i;	
		}
		
		public  int DeleteBlogotype(int t_blogtype_id)
		{
			int i=SqlDBHelp.GetExecute("delete from Blogotypes where blogtype_id="+t_blogtype_id);
			return i;
		}
	}
}


