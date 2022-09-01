﻿#!/bin/bash
sudo systemctl stop RestAPI
git pull origin backend-main
sudo cp RestAPI.service /etc/systemd/system/RestAPI.service
sudo systemctl daemon-reload
dotnet publish -c Release -o /srv/RestAPI/
sudo systemctl start RestAPI