using System;

namespace Support.Application.Contract.DTO
{
public class LogDTO
{
public int LogId { get; set; } 
public DateTime Date { get; set; } 
public string EntityName { get; set; } 
public int PersonId { get; set; } 
public string Description { get; set; } 
public int ChangeTypeId { get; set; } 
public int PrimaryKey { get; set; } 
public string Person { get; set; }
    public string PersonName { get; set; }
}
}