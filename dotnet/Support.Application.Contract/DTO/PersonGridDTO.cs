
namespace Support.Application.Contract.DTO
{
	public class PersonGridDTO
    {	    
       	   public int PersonId {get;set;}
	   	   public string FullName {get;set;}
	   	   public string UserName {get;set;}
	   	   public string Email {get;set;}
	   	   public string Mobile {get;set;}
	   	   public string CompanyName {get;set;}
	   	   public string Gender {get;set;}
	   	   public string Status {get;set;}
           public int StatusId { get; set; }
    }
}