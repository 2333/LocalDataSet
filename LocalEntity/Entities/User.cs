using System;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace LocalEntity.Entities
{
	 	//User
		public class User
	{
	
      	/// <summary>
		/// Id
        /// </summary>
        public virtual Guid Id
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Name
        /// </summary>
        public virtual string Name
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Password
        /// </summary>
        public virtual string Password
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Email
        /// </summary>
        public virtual string Email
        {
            get; 
            set; 
        }        
		/// <summary>
		/// FLAG
        /// </summary>
        public virtual int? FLAG
        {
            get; 
            set; 
        }        
		   
	}
}