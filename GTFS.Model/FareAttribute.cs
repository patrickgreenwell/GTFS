using System;
using System.ComponentModel.DataAnnotations;

namespace GTFS.Model
{
    /// <summary>
    /// Fare information for a transit organization's routes.
    /// </summary>
    public class FareAttribute
    {
        /// <summary>
        /// The fare_id field contains an ID that uniquely identifies a fare class. The fare_id is dataset unique.
        /// </summary>
        [Key, Required]
        public string fare_id { get; set; }

        /// <summary>
        /// The price field contains the fare price, in the unit specified by <see cref="GTFS.Model.FareAttribute.currencty_type"/>
        /// </summary>
        [Required]
        public string price { get; set; }

        /// <summary>
        /// The currency_type field defines the currency used to pay the fare. Please use the ISO 4217 alphabetical currency codes.
        /// </summary>
        [Required]
        public string currency_type { get; set; }

        /// <summary>
        /// The payment_method field indicates when the fare must be paid. Valid values for this field are:
        /// <list type="bullet">
        /// <item><description> 0 - Fare is paid on board.</description></item>
        /// <item><description>1 - Fare must be paid before boarding.</description></item>
        /// </list>
        /// </summary>
        [Required]
        [Range(0, 2)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public ushort? payment_method { get; set; }

        /// <summary>
        /// The transfers field specifies the number of transfers permitted on this fare. Valid values for this field are:
        /// <list type="bullet">
        /// <item><description>0 - No transfers permitted on this fare.</description></item>
        /// <item><description>1 - Passenger may transfer once.</description></item>
        /// <item><description>2 - Passenger may transfer twice.</description></item>
        /// <item><description>(empty) - If this field is empty, unlimited transfers are permitted.</description></item>
        /// </list>
        /// </summary>
        [Required]
        public string transfers { get; set; }

        /// <summary>
        /// The transfer_duration field specifies the length of time in seconds before a transfer expires.
        /// <remarks>
        /// When used with a transfers value of 0, the transfer_duration field indicates how long a ticket is valid for a fare where no transfers are allowed. Unless you intend to use this field to indicate ticket validity, transfer_duration should be omitted or empty when <see cref="GTFS.Model.FareAttribut.transfers"/>transfers is set to 0.
        /// </remarks>  
        /// </summary>
        public string transfer_duration { get; set; }
    }
}
