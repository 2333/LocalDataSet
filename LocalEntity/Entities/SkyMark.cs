using System;

//Nhibernate Code Generation Template 1.0
//author:MythXin
//blog:www.cnblogs.com/MythXin
//Entity Code Generation Template
namespace LocalEntity.Entities
{
	 	//SkyMark
		public class SkyMark
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
		/// Name
        /// </summary>
        public virtual string Name
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Cotlog
        /// </summary>
        public virtual string Cotlog
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Dec
        /// </summary>
        public virtual decimal? Dec
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Ra
        /// </summary>
        public virtual decimal? Ra
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Remark
        /// </summary>
        public virtual string Remark
        {
            get; 
            set; 
        }        
		/// <summary>
		/// SaveTime
        /// </summary>
        public virtual DateTime? SaveTime
        {
            get; 
            set; 
        }

        public virtual String Brush
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