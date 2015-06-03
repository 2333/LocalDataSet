using System;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace LocalEntity.Entities
{
	 	//Record
		public class Record
	{
	
      	/// <summary>
		/// table_name
        /// </summary>
        public virtual string table_name
        {
            get; 
            set; 
        }        
		/// <summary>
		/// update_time
        /// </summary>
        public virtual DateTime? update_time
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ID
        /// </summary>
        public virtual int ID
        {
            get; 
            set; 
        }        
		   
	}
}