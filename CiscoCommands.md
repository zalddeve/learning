# Oktatás 2022

## Feladatok

- [Oktatas.hu > KöznevelésÉrettségi > Központi írásbeli feladatsorok, javítási útmutatók](https://www.oktatas.hu/kozneveles/erettsegi/feladatsorok):  
  `informatikai ismeretek`

## Cisco Packet Tracer

- Download: [Cisco Skills For All](https://skillsforall.com/resources/lab-downloads)

## Kérdések

- Program verziók:
  - Cisco Packet Tracer
  - Visual Studio
  - .NET (dotnet core-ban lehet fejleszteni)
  - SQL Server
  - SSMS
- Milyen segédezközt helet használni?
- Egyéb program telepíthető?
  - vs-code
  - SSMS Boost
  - git
  - ...

## Basic commands

```bash
enable
configure terminal

hostname Akarmi

exit

show running-config
copy running-config startup-config

write memory

reload
```

## User Management

```
enable password jelszo
# or
enable secret titkos-jelszo

# Create user:
username admin password admin
username kutato password sark123

# Select virtual lines 0-15:
lin vty 0 15
  # set passwd for telnet:
  password admin
  # enable login:
  login

  # enable login for local users (pl. kutato)
  login local
```

## Save file from telnet

```
SZOLGALTATO#copy running-config tftp
Address or name of remote host []? 10.0.20.1
Destination filename [SZOLGALTATO-confg]? szolgaltato.conf

Writing running-config...!!
[OK - 1133 bytes]

1133 bytes copied in 0.037 secs (30621 bytes/sec)
```

## IP Configuration

```bash
enable
configure terminal
interface GigabitEthernet 0/0
ip address 20.255.255.254 255.0.0.0
shutdown
```

## DHCP CLI configuration

[youtube](https://www.youtube.com/watch?v=q29_iMZaRDA)

```bash
Press RETURN to get started.

# Enter root mode
OFFICE> enable
# Start global config
OFFICE> conf t
  Enter configuration commands, one per line.  End with CNTL/Z.

# DHCP first/last 5 IPs excluded
OFFICE(config)> ip dhcp excluded-address 20.0.0.1 20.0.0.5
OFFICE(config)> ip dhcp excluded-address 20.255.255.250 20.255.255.254

# Create pool named 'OFFICE'
OFFICE(config)>      ip dhcp pool OFFICE
# Get help
OFFICE(dhcp-config)> ?
# Set network and subnet mask
OFFICE(dhcp-config)> network 20.0.0.0 255.0.0.0
# Default gateway
OFFICE(dhcp-config)> default-router 20.255.255.254
OFFICE(dhcp-config)> dns-server 11.11.11.11
OFFICE(dhcp-config)> exit
```

## OSPF

```bash
router ospf 1911
 log-adjacency-changes
 passive-interface GigabitEthernet0/0
 network 40.40.40.0 0.0.0.3 area 0
 network 172.18.40.0 0.0.0.255 area 0
```

## Subnet Mask Explained

[youtube](https://www.youtube.com/watch?v=s_Ntt6eTn94)

32 bit number => 4 x 8 octet

Subnet mask = 255.255.255.0
IP address  = Network address + Host address
              192.168.1.0     + 192.168.1.2

Subnet mask defines what is net and what is host address

in binary:

```
8 bit octet chart
128 64 32 16 8 4 2 1
```

```
255.255.255.0
11111111.11111111.11111111.00000000
192.168.1.0
11000000.10101000.00000001.00000000
```

```
255.255.255.128
11111111.11111111.11111111.10000000
192.168.1.0
11000000.10101000.00000001.00000000
```

```
CIDR - Classless inter-domain routing (slash notation)
192.168.1.0/24
11111111.11111111.11111111.00000000
==>
Network address: 192.168.1.0
Subnet mask:     255.255.255.0

192.168.1.0/26
11111111.11111111.11111111.11000000
===>
Network address: 192.168.1.0
Subnet mask:     255.255.255.192
```

11111111.11111111.11111111.11000000
255.255.255.192
