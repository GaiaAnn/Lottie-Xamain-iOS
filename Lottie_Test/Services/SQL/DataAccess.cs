using System;
using System.Collections.Generic;
using System.IO;
using Lottie_Test.Common;
using SQLite;
namespace Lottie_Test.Services.SQL
{
	public class UserInfo
	{
		[PrimaryKey]//員工編號  
		public int Id { get; set; }

		public string Userid { get; set; }

		public bool DeviceStatus { get; set; }

		public int RSSIAdjustValue { get; set; }
		//access_token
		public string Access_Token { get; set; }
		//tenantId 
		public string TenantId { get; set; }
		//PerserilNo
		public string PerserilNo { get; set; }
		//CompanyId
		public string CompanyId { get; set; }

	}

	public class Beacon
	{
		[PrimaryKey, MaxLength(200)]
		public string BEACON_ID { get; set; }
		public string UUID { get; set; }
		public string MAJOR_ID { get; set; }
		public string MINOR_ID { get; set; }
		public string BEACON_TYPE { get; set; }
		public string TX_POWER { get; set; }
		public string IS_ENABLE { get; set; }
		public string EXTEND_VALUE { get; set; }
		public string LOCATION { get; set; }
		public string DESCRIPTION { get; set; }
		public string CRE_DTE { get; set; }
		public bool IsDoorBeacon => string.Compare(IS_ENABLE, Variables.TRUE, true) == 0;
		public int CATEGORY_ID { get; set; }

		//[OneToMany]
		//public virtual List<CATEGORY> BEACON_CATEGORY { get; set; }
		//ublic Category1 Category { get; set; }

		public int PUSH_ACTION_ID { get; set; }//Update //Modify
		public string PUSH_ALERT { get; set; }
	}

	#region oneTomany Fail
	//public class CATEGORY
	//{
	//  [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
	//  public int ID { get; set; }

	//  [ForeignKey(typeof(Beacon))]     // Specify the foreign key
	//  public int CATEGORY_ID { get; set; }
	//  public string CATEGORY_NAME { get; set; }
	//  public string POST_URL { get; set; }
	//  public string HOOK_URL { get; set; }
	//  public string CRE_DTE { get; set; }

	//  //[OneToMany]
	//  //public List<CATEGORY_ACTIONS> CATEGORY_ACTIONS { get; set; }

	//}
	//public class Category1
	//{

	//  public Category1()
	//  {
	//      Beacons = new List<Beacon>();
	//  }
	//  public int Id { get; set; }
	//  public string Description { get; set; }
	//  public int ActionId { get; set; }
	//  public string Action_Description { get; set; }
	//  public string PostURL { get; set; }

	//  public ICollection<Beacon> Beacons { get; set; }

	//}
	//public class CategoryAction
	//{
	//  [PrimaryKey]//Identity Field
	//  public int Id { get; set; }
	//  public int CategoryId { get; set; }
	//  public int ActionId { get; set; }
	//  public string Action_Description { get; set; }
	//  public string PostURL { get; set; }
	//    //read url or webhook
	//}

	#endregion

	public class Category
	{
		[PrimaryKey]
		public int CATEGORY_ID { get; set; }
		public string CATEGORY_NAME { get; set; }
		public string HOOK_URL { get; set; }
		public string CRE_DTE { get; set; }

	}

	public class Actions
	{
		[PrimaryKey]
		public int ID { get; set; }
		public int CATEGORY_ID { get; set; }
		public int ACTION_ID { get; set; }
		public string ACTION_NAME { get; set; }
		public string CRE_DTE { get; set; }
		public int ACTION_TYPE { get; set; }
		//read url or webhook
	}



	public class UserRecieveInfo
	{
		public string USER_ID { get; set; }
		public string BEACON_ID { get; set; }
		public int RSSI { get; set; }
		public string CRE_DTE { get; set; }
		public decimal DISTANCE { get; set; }
		public string DESCRIPTION { get; set; }
		public int RSSI_OFFSET { get; set; }
		public int CATEGORY_ID { get; set; }
		public int ACTION_ID { get; set; }
		public int ACTION_TYPE { get; set; }
	}

	public class UserReceiveDays//WorkTime Model共用
	{
		public string USER_ID { get; set; }
		public string CRE_DATE { get; set; }
		public string AM_TIME { get; set; }
		public string PM_TIME { get; set; }
		public string FIX_AM_TIME { get; set; }
		public string FIX_PM_TIME { get; set; }
		public string DESCRIPTION { get; set; }
		public string FIX_DTE { get; set; }
		public string WORKING_HOURS { get; set; }
		public bool IS_OVER_WORKING_HOURS { get; set; }
	}

	public class BehorUserReceiveDays
	{
		public string empId { get; set; }
		public string empCName { get; set; }
		public DateTime? shiftSDate { get; set; }
		public DateTime? shiftEDate { get; set; }
		public DateTime? amTime { get; set; }
		public DateTime? pmTime { get; set; }
		public string workingStatus { get; set; }
		public string workingStatusShow { get; set; }
	}

	public class BehorUserRecieveInfo
	{
		public string UserId { get; set; }
		public DateTime WorkDateTime { get; set; }
	}
	public class BehorCardDetail
	{
		public string empId { get; set; }
		public string empCName { get; set; }
		public string cardTime { get; set; }
	}


	public class BaseDAO<T> where T : new()
	{
		public string dbPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.Personal), "GssBeacon.db3");

		public List<T> QueryAll()
		{
			using (var db = new SQLiteConnection(dbPath))
			{
				try
				{
					db.CreateTable<T>();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}

				var datas = db.Table<T>();
				var result = new List<T>();
				foreach (T data in datas)
				{
					result.Add(data);
				}
				return result;
			}
		}


		public void DeleteAll()
		{
			using (var db = new SQLiteConnection(dbPath))
			{
				db.CreateTable<T>();
				db.DeleteAll<T>();
			}
		}


		public void InsertOrReplace(T data)
		{
			using (var db = new SQLiteConnection(dbPath))
			{
				db.CreateTable<T>();
				db.InsertOrReplace(data);
			}
		}


		public void UpdateAll(List<T> datas)
		{
			using (var db = new SQLiteConnection(dbPath))
			{
				db.CreateTable<T>();
				db.DeleteAll<T>();
				foreach (T data in datas)
				{
					db.InsertOrReplace(data);
				}
			}
		}
	}

}

