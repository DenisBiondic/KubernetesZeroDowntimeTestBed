using System;
using System.Threading;
using System.Threading.Tasks;
using Prometheus;
using System.Net;
using System.Net.Http;

namespace Watchdog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var metricServer = new Prometheus.MetricServer(port: 8090);
            metricServer.Start();

            while (true)
            {
                if (IsAvailable().Result)
                {
                    ReportIsHealthy();
                }
                else
                {
                    ReportIsBroken();
                }

                // a very high sample rate through sleeping only a little
                Thread.Sleep(100);
            }
        }

        public static async Task<bool> IsAvailable()
        {
            var targetUrl = GetTargetUrl();
            
            try {
                var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(3) };

                var httpResponse = await httpClient.GetAsync(targetUrl);

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                    Console.WriteLine($"{DateTime.Now} Response ({targetUrl}): {httpResponse.StatusCode})");

                var httpResponseString = await httpResponse.Content.ReadAsStringAsync();

                return httpResponseString == "hello";
            }
            catch (HttpRequestException requestException) 
            {
                Console.WriteLine($"{DateTime.Now} Target ({targetUrl}) was unavailable: {requestException.Message}");
                return false;
            }
            catch (Exception exception) 
            {
                Console.WriteLine($"{DateTime.Now} Unknown exception: {exception}");
                return false;
            }
        }

        private static string GetTargetUrl()
        {
            var baseUrl = "http://fancy-service:8080";
            return $"{baseUrl}/api/test";
        }

        public static void ReportIsHealthy()
        {
            Report(1.0);
        }

        public static void ReportIsBroken()
        {
            Report(0);
        }

        public static void Report(double metricValue)
        {
            var healthGauge = Metrics.CreateGauge("watchdog_fancy_service_alive", "Fancy service availability");
            healthGauge.Set(metricValue);
        }
    }
}
