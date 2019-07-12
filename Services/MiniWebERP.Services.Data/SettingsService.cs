namespace MiniWebERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MiniWebERP.Data.Common.Repositories;
    using MiniWebERP.Data.Models;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.All().Count();
        }
    }
}
