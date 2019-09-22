using System;
using System.Data.Entity.Infrastructure;
using Support.Application.Contract.Constant;
using Support.Domain.Model;

namespace Support.DataAccess.EF
{
    public class ChangeLog
    {
            public Log GetDataChangeLogModel(DbEntityEntry change, int primaryKey, int personId)
            {

                var changeTime = DateTime.Now;
                var entityName = change.Entity.GetType().Name;
                var changeDetailJsonForm = ChangeDetailJsonForm(change);

                var log = GetDataChangeLogDTO(entityName, primaryKey, personId, changeDetailJsonForm, changeTime);
                return log;
            }

            private static Log GetDataChangeLogDTO(string entityName, int primaryKey, int personId, string changeDetailJsonForm,
                DateTime changeTime)
            {
                var entityExactName = entityName.Split('_')[0];
                if (changeDetailJsonForm != "{")
                {
                    Log log = new Log()
                    {
                        EntityName = entityExactName,
                        PrimaryKey = primaryKey,
                        ChangeTypeId = DataChangeLogMode.Edit,
                        PersonId = personId,
                        Description = changeDetailJsonForm,
                        Date = changeTime
                    };
                    return log;
                }
                return null;
            }

            private static string ChangeDetailJsonForm(DbEntityEntry change)
            {
                try
                {

                    var changeDetailJsonForm = "{";
                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        var originalValue = change.OriginalValues[prop]?.ToString() ?? "";
                        var currentValue = change.CurrentValues[prop]?.ToString() ?? "";
                        if (originalValue != currentValue)
                        {
                            changeDetailJsonForm += string.Format("'{0}':'{1}',", prop,
                                originalValue + " to " + currentValue);
                        }
                    }
                    changeDetailJsonForm = changeDetailJsonForm.Remove(changeDetailJsonForm.Length - 1, 1);
                    changeDetailJsonForm += "}";
                    return changeDetailJsonForm;
                }
                catch (Exception ex)
                {
                    return "Save Log Error";
                }

            }



        }
    }
