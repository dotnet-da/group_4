#!/bin/bash
sudo mkdir /srv/RestAPI
sudo chown root /srv/RestAPI/
dotnet publish -c Release -o /srv/RestAPI/
sudo cp RestAPI.service /etc/systemd/system/RestAPI.service
sudo systemctl daemon-reload