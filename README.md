# KubernetesZeroDowntimeTestBed

A simple test bed with some sample services and a monitoring solution to showcase zero downtime scenarios.

## FancyService

Target service to deploy and monitor for downtime through different scenarios. An ASP.NET Core application with a REST interface.

## Monitoring

components for monitoring the downtime

#### Prometheus & Grafana

Monitoring / scraping tool and dashboard

#### Watchdog

A custom component for Prometheus to scrape which can query the FancyService much more often