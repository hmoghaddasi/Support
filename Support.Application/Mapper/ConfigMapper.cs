using Support.Application.Contract.DTO;
using Support.Domain.Model;

namespace Support.Application.Mapper
{
   public class ConfigMapper
    {
        public static ConfigDTO Map(Config config)
        {
            return new ConfigDTO()
            {
                ConfigId = config.ConfigId,
                ConfigHdrId = config.ConfigHdrId,
                ConfigName = config.ConfigName,
                ConfigValue = config.ConfigValue,
                ConfigNote = config.ConfigNote,
                ConfigSort = config.ConfigSort,
                ClassName= config.ClassName

            };
        }
      
        public static Config MapToModel(ConfigDTO config)
        {
            return new Config()
            {
                ConfigId = config.ConfigId,
                ConfigHdrId = config.ConfigHdrId,
                ConfigName = config.ConfigName,
                ConfigValue = config.ConfigValue,
                ConfigNote = config.ConfigNote,
                ConfigSort = config.ConfigSort,
                ClassName = config.ClassName
            };
        }
        public static Config MapToEditModel(Config model, ConfigDTO dto)
        {
            model.ConfigName = dto.ConfigName;
            model.ConfigHdrId = dto.ConfigHdrId;
            model.ClassName = dto.ClassName;
            model.ConfigNote = dto.ConfigNote;
            model.ConfigValue = dto.ConfigValue;
            model.ConfigSort = dto.ConfigSort;
            return model;
        }
   
    }

}
