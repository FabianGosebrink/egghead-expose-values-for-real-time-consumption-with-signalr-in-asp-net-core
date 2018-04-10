using System;

namespace egghead_expose_values_for_real_time_consumption_with_signalr_in_asp_net_core.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}