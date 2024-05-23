using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreCV.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        //ViewComponenete bağlı çalışacak olan viewlar Shared/Components içerisinde aranacaktır burada ki sınıf ismi ile view ismi aynı olmalıdır.
        //Bu program çekrideğinde olusan bir kural gibi düşün
        public IViewComponentResult Invoke()
        {
            var datas = featureManager.TGetList();
            return View(datas);
        }
    }
}
