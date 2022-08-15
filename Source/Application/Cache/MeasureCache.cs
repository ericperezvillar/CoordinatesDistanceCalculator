using Application.Interfaces;
using DataModel.Measures;
using Infrastructure.DataAccess.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Cache
{
    public class MeasureCache : IMeasureCache
    {
        private readonly ICacheHelper _cacheHelper;
        private readonly IMeasureRepository _measureRepository;
        private readonly SettingsEnvironment _settingsEnvironment;

        public MeasureCache(ICacheHelper cacheHelper, IMeasureRepository measureRepository, IOptions<SettingsEnvironment> settingsEnvironment)
        {
            _cacheHelper = cacheHelper;
            _measureRepository = measureRepository;
            _settingsEnvironment = settingsEnvironment.Value;
        }

        public async Task<Measure> GetMeasureByNameAsync(string name)
        {
            var measureList = _cacheHelper.Get<List<Measure>>(SettingsApplication.MeasureCacheKey);

            if(measureList == null)
            {
                var measureListDb = await _measureRepository.GetAllAsync();
                _cacheHelper.Add(measureListDb, SettingsApplication.MeasureCacheKey, DateTimeOffset.Now.AddSeconds(_settingsEnvironment.MemoryCacheTimeoutMeasure));
                return measureListDb.FirstOrDefault(x => string.Equals(x.Name,name, StringComparison.InvariantCultureIgnoreCase));
            }

            return measureList.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
