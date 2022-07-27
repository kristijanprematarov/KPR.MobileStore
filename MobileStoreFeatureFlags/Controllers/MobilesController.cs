using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using MobileStoreFeatureFlags.Features;
using MobileStoreFeatureFlags.Models;
using MobileStoreFeatureFlags.Services;

namespace MobileStoreFeatureFlags.Controllers
{
    [Authorize]
    [FeatureGate(nameof(FeatureFlags.MobileReview))]
    public class MobilesController : Controller
    {
        private readonly IMobileDataService _mobileDataService;

        public MobilesController(IMobileDataService mobileDataService)
        {
            _mobileDataService = mobileDataService;
        }

        public IActionResult Index()
        {
            List<Mobile> mobiles = _mobileDataService.GetAllMobiles();
            return View(mobiles);
        }

        [FeatureGate(nameof(FeatureFlags.MobileDetailedReview))]
        public IActionResult ReviewDetails(string? mobileId)
        {
            Mobile mobile = _mobileDataService.GetAllMobiles()
                .Find(p => p.Id.Equals(mobileId));

            return View(mobile);
        }
    }
}
