using System;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace LocalEntity.Entities
{
	 	//DingBiao
	public class DingBiao
	{
	
      	/// <summary>
		/// ID
        /// </summary>
        public virtual int ID
        {
            get; 
            set; 
        }        
		/// <summary>
		/// TYPE
        /// </summary>
        public virtual string TYPE
        {
            get; 
            set; 
        }        
		/// <summary>
		/// STARTTME
        /// </summary>
        public virtual string STARTTIME
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ENDTIME
        /// </summary>
        public virtual string ENDTIME
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PLANID
        /// </summary>
        public virtual string PLANID
        {
            get; 
            set; 
        }        
		   
	}
}