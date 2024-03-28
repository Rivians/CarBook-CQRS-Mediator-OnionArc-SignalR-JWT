using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();                                         /*   1    */
        int GetLocationCount();                                    /*   2    */
        int GetAuthorCount();                                      /*   3    */      
        int GetBlogCount();                                        /*   4    */
        int GetBrandCount();                                       /*   5    */
        decimal GetAvgRentPriceForDaily();                         /*   6    */
        decimal GetAvgRentPriceForWeekly();                        /*   7    */
        decimal GetAvgRentPriceForMonthly();                       /*   8    */    
        int GetCarCountByTransmissionIsAuto();                     /*   9    */
        string GetBrandNameByMaxCar();                             /*   10   */
        string GetBlogTitleByMaxBlogComment();                     /*   11   */
        int GetCarCountByKmSmallerThan1000();                      /*   12   */
        int GetCarCountByFuelGasolineOrDiesel();                   /*   13   */
        int GetCarCountByFuelElectric();                           /*   14   */
        string GetCarBrandAndModelByRentPriceDailyMax();           /*   15   */
        string GetCarBrandAndModelByRentPriceDailyMin();           /*   16   */
    }
}
