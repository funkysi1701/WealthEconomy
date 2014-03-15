//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessObjects.Dto
{
    using System;
    
    public class SectorDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
    	
    	public Sector ToBusinessObject()
    	{
    		return new Sector()
    		{
    			Id = Id, 
    			Name = Name, 
    			Description = Description, 
    			CreatedOn = CreatedOn, 
    			ModifiedOn = ModifiedOn, 
    			DeletedOn = DeletedOn
    		};
    	}
    }
}