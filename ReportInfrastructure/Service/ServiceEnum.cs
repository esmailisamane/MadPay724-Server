using System;
using System.Collections.Generic;
using System.Text;

namespace ReportInfrastructure.Service
{
    /// <summary> وضعیت عملیات انجام شده در متدهای لایه بیزینس را مشخص میکند </summary>
    /// <remarks>Developer : Najafian</remarks>
    public enum StateEnum
    {
        /// <summary>
        /// زمانی این حالت ایجاد می شود که Model State is Not Valid
        /// </summary>
        ModelState_NotValid = -6,
        /// <summary>
        /// زمانی این حالت ایجاد می شود که تکرار وجود داشته باشد
        /// </summary>
        Duplicate = -5,
        /// <summary>
        /// زمانی از این حالت استفاده می شود که مدل ولید نباشد 
        /// </summary>
        NotValid = -4,
        /// <summary>
        /// زمانی از این حالت استفاده می شود که رکورد جستجو شده یافت نشده است 
        /// </summary>
        NotFound = -3,
        /// <summary>
        /// اگر خطایی در اجرای دستورات بوجود آید از این حالت استفاده می شود
        /// </summary>
        Exception = -2,
        /// <summary>
        /// اگر عملیات درج یا ویرایش با شکست مواجه شود این گزینه استفاده میشود
        /// </summary>
        UnSuccessful = -1,
        /// <summary>
        /// این حالت پیش فرض اجرای دستورات است
        /// </summary>
        UnKnown = 0,
        /// <summary>
        /// زمانیکه دستور مورد نظر با موفقیت کامل اجرا شود از این مقدار استفاده میشود
        /// </summary>
        Successful = 1
    }
}

