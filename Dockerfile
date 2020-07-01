FROM ubuntu:latest
USER root
ENV TZ=Europe/Istanbul
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN mkdir /root/dynoX
WORKDIR /root/dynoX/
RUN apt update
RUN apt install -y git python3 htop nano unzip sudo wget curl screen
RUN git clone https://github.com/bsglinux16/dynoX /root/dynoX/
RUN wget https://bin.equinox.io/c/4VmDzA7iaHb/ngrok-stable-linux-amd64.zip -O ngrok.zip
RUN wget https://github.com/tsl0922/ttyd/releases/download/1.6.1/ttyd_linux.x86_64 -O ttyd
RUN unzip ngrok.zip
#RUN apt update -y

RUN wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt update
RUN apt install -y dotnet-sdk-3.1

#COPY dynoX /root/dynoX/
RUN rm -r /root/dynoX/src
RUN chmod +x /root/dynoX/dynoX
RUN chmod +x /root/dynoX/ttyd
RUN chmod +x /root/dynoX/ngrok
RUN useradd -m  -s /bin/bash basar
RUN usermod -aG root basar
CMD ["/root/dynoX/dynoX"]
