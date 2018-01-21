# using the grafana master branch until grafana 4.7 is officialy out (the configuration as code feature is still in development)
FROM grafana/grafana:master

ADD configuration/grafana.ini /etc/grafana/grafana.ini
ADD configuration/provisioning-conf /etc/grafana/provisioning-conf
ADD configuration/dashboards /etc/grafana/dashboards