# Oktatás 2022

## Feladatok

- [Oktatas.hu > KöznevelésÉrettségi > Központi írásbeli feladatsorok, javítási útmutatók](https://www.oktatas.hu/kozneveles/erettsegi/feladatsorok):  
  `informatikai ismeretek`

## Cisco Packet Tracer

- Download: [Cisco Skills For All](https://skillsforall.com/resources/lab-downloads)

## Alap parancsok

```bash
# Belépés privilegizált módba
enable
# Belépés konfigurációs módba
configure terminal
# Kilépés egy szinttel feljebb
exit
# Help menü
?

# Hosztnév beállítása
ROUTER(config)> hostname Akarmi

# Futó konfiguráció megjelenítése a konzolon
ROUTER> show running-config
# Futó konfiguráció másolása az indítási konfigurációba
ROUTER> copy running-config startup-config
ROUTER> write memory

# Eszköz újraindítása
ROUTER> reload
```

## Felhasználókezelés

```bash
# Jelszó beállítása privilegizált módhoz
ROUTER(config)> enable password jelszo
ROUTER(config)> enable secret titkos-jelszo

# Felhasználó létrehozása
ROUTER(config)> username admin password admin
ROUTER(config)> username kutato password sark123
```

## Távoli hozzáférés (Telnet és/vagy SSH)

```bash
# Virtuális vonalak kiválasztása:
ROUTER(config)> line vty 0 15

# Belépés engedélyezése csak jelszóval
ROUTER(config-line)> password jelszó
ROUTER(config-line)> login

# Belépés engedélyezése helyi felhasználónak (pl. kutato)
ROUTER(config-line)> login local

# Távoli hozzáférési protokol megadás:
ROUTER(config-line)> transport input ?
  all     All protocols
  none    No protocols
  ssh     TCP/IP SSH protocol
  telnet  TCP/IP Telnet protocol
```

```bash
# Futó konfiguráció mentése fájlba egy másik szerverre
ROUTER> copy running-config tftp
  Address or name of remote host []? 10.0.20.1
  Destination filename [SZOLGALTATO-confg]? szolgaltato.conf
```

## Távoli hozzáférés (Összetett példa)

"Az R_FORNAX forgalomirányító első 5 virtuális vonalán állítsa be, hogy távolról csak SSH protokollal lehessen elérni az eszközt! Használjon helyi hitelesítést a vonalakon!  
A szükséges felhasználó neve foradmin, jelszava forpass legyen! Állítsa be, hogy az eszköz domain neve fornax.com legyen! Engedélyezze az SSH 2-es verzióját! Használjon hozzá 2048 bites kulcsot!"

```bash
# Hostnév és domain név beállítása
R_FORNAX(config)> hostname R_FORNAX
R_FORNAX(config)> ip domain-name fornax.com

# 2048 bites RSA kulcs generálása
R_FORNAX(config)> crypto key generate rsa
  How many bits in the modulus [512]: 2048

# SSH version 2 engedélyezése
R_FORNAX(config)> ip ssh version 2

# Felhasználó létrehozása
R_FORNAX(config)> username foradmin password forpass

# Első 5 virtuális vonal kiválasztása
R_FORNAX(config)> line vty 0 4

# Helyi hitelesítés használata (aka. belépés local felhasználóval)
R_FORNAX(config-line)> login local

# Csak SSH protokol engedélyezése
R_FORNAX(config-line)> transport input ssh
```

## Domain név megadása

```bash
ROUTER(config)> ip domain-name fornax.com
```

## IP konfiguráció switch-en

```bash
# Virtuális hálózat kiválasztása
SWITCH(config)> interface Vlan 1
# IP cím és hálózati maszk megadása
SWITCH(config-if)> ip address 172.18.40.253 255.255.255.0
SWITCH(config-if)> exit
# Alapértelmezett átjáró beállítása
SWITCH(config)> ip default-gateway 172.18.40.254
```

## IP konfiguráció router-en

```bash
# Interface kiválasztása
ROUTER(config)> interface GigabitEthernet 0/0
# IP cím és hálózati maszk megadása
ROUTER(config)> ip address 20.255.255.254 255.0.0.0
ROUTER(config-if)> exit
# Alapértelmezett átjáró beállítása
ROUTER(config)> ip default-gateway 20.255.255.254
```

## DHCP konfiguráció

[youtube](https://www.youtube.com/watch?v=q29_iMZaRDA)

```bash
# Az első és utolsó öt IP cím kizárása a DHCP tartományból
ROUTER(config)> ip dhcp excluded-address 20.0.0.1 20.0.0.5
ROUTER(config)> ip dhcp excluded-address 20.255.255.250 20.255.255.254

# DHCP pool létrehozása 'OFFICE' néven
ROUTER(config)> ip dhcp pool OFFICE
# Hálózati cím és hálózati maszk megadása
ROUTER(dhcp-config)> network 20.0.0.0 255.255.255.0
# Alapértelmezett átjáró megadása
ROUTER(dhcp-config)> default-router 20.255.255.254
# DNS szerver beállítása
ROUTER(dhcp-config)> dns-server 11.11.11.11
```

Létrehozott DHCP pool(ok) kiíratása:

```bash
ROUTER> show ip dhcp pool 

Pool OFFICE :
 1 subnet is currently in the pool
 Current index        IP address range                    Leased/Excluded/Total
 20.0.0.1             20.0.0.1         - 20.0.0.254        0    / 0     / 254
```

## VLAN konfiguráció

![VLAN](./images/vlan-notes.jpg)

**Router** beállítása:

- GigabitEthernet0/0/0: `on`

- Alinterfészek létrehozása a `192.168.10.0/25` és `192.168.10.128/25` hálózatokhoz.  
  (Az alinterfészek hálózati címe a tartomány első kiosztható IP címe lesz.)

  - ```bash
    Router(config)> interface GigabitEthernet0/0/0.10
    Router(config-subif)> encapsulation dot1Q 10
    Router(config-subif)> ip address 192.168.10.1 255.255.255.128
    ```

  - ```bash
    Router(config)> interface GigabitEthernet0/0/0.20
    Router(config-subif)> encapsulation dot1Q 20
    Router(config-subif)> ip address 192.168.10.129 255.255.255.128
    ```

- DHCP pool-ok (`P10` és `P20`) létrehozása a fenti hálózatokhoz:

  - ```bash
    Router(config)> ip dhcp pool P10
    Router(dhcp-config)> network 192.168.10.0 255.255.255.128
    Router(dhcp-config)> default-router 192.168.10.1
    Router(dhcp-config)> dns 8.8.8.8
    ```

  - ```bash
    Router(config)> ip dhcp pool P20
    Router(dhcp-config)> network 192.168.10.128 255.255.255.128
    Router(dhcp-config)> default-router 192.168.10.129
    Router(dhcp-config)> dns 8.8.8.8
    ```

**Switch1** és **Switch2** beállítása:

- `VLAN Database` megadása mindkét kapcsolón:  
  ![vlan-database](images/vlan-database.jpg)
- `Trunk` mód beállítása a kapcsoló és router irányába:  
  ![vlan-trunk](images/vlan-trunk.jpg)
- `Access` mód beállítása és VLAN kiválasztása a PC-k irányába:  
  ![vlan-access](images/vlan-access.jpg)

## Static NAT

![Static NAT](images/nat.jpg)

```bash
Router(config)# ip nat inside source static 172.20.40.22 65.54.23.3

Router(config)# interface GigabitEthernet 0/0/0
Router(config-if)# ip nat inside 
Router(config-if)# exit

Router(config)# interface GigabitEthernet 0/0/1
Router(config-if)# ip nat outside 
Router(config-if)# exit
```

```bash
ip nat inside source static 172.18.40.250 30.30.30.14 
ip classless
ip route 0.0.0.0 0.0.0.0 GigabitEthernet 0/1
ip flow-export version 9
```

## OSPF

A `SOUTH_NET` és `WEATHER&CLIMATE` hálózatok hirdetése OSPF-el.  
A `NORD_LAN` nincs hirdetve! (Ha az is kellene, akkor hozzá kell adni a `network 30.30.30.0 0.0.0.15 area 0` parancsot is az OSLO router-hez.)

![OSPF net](images/ospf-network.jpg)

```bash
# OSPF konfigurálása 1911-es folyamatazonosítóval
OSLO(config)> router ospf 1911
OSLO(config-router)> log-adjacency-changes
# OSLO router-hez csatlakozó hálózatok (kivéve NORD_LAN)
OSLO(config-router)> network 40.40.40.0 0.0.0.3 area 0
OSLO(config-router)> network 172.18.40.0 0.0.0.255 area 0
```

```bash
# OSPF konfigurálása 1911-es folyamatazonosítóval
SOUTH(config)> router ospf 1911
SOUTH(config-router)> log-adjacency-changes
# SOUTH router-hez csatlakozó hálózatok
SOUTH(config-router)> network 10.10.10.0 0.0.0.3 area 0
SOUTH(config-router)> network 40.40.40.0 0.0.0.3 area 0
```

```bash
# Routing információk lekérdezése ellenőrzéshez
# (Az "O" jelzést kell keresni)
OSLO> route
SOUTH> route
```

## ACL (Accesc Control List)

Hozzáférési lista megadása

```bash
# Első ACL lista:
# 172.20.40.0 hálózat tiltása, kivéve 172.20.40.12
Router(config)> access-list 1 permit 172.20.40.12
Router(config)> access-list 1 deny 172.20.40.0 255.255.255.0

# Második ACL lista:
Router(config)> access-list 2 deny 192.168.1.0 255.255.255.0
```

## Hálózatik címek

[youtube](https://www.youtube.com/watch?v=s_Ntt6eTn94)

|  | /30 | /29 | /28 | /27 | /26 | /25 | /24 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Összes IP | 4 | 8 | 16 | 32 | 64 | 128 | 254 |
| Kiosztható | 2 | 6 | 14 | 30 | 62 | 126 | 252 |
| Maszk | 252 | 248 | 240 | 224 | 192 | 128 | 0 |

> 192.168.10.128/25
```bash
Network address:   `192.168.10.128`
NetMask(02):       `11111111.11111111.11111111.10000000`
NetMask(10):       `255.255.255.128`
Broadcast:
  0111111 = 127
  128 + 127 = 255
  192.168.10.255
IP Range:  129-254
```

> 192.168.30.32/27

```bash
Network address:   `192.168.30.32`
Net mask binary:   `11111111.11111111.11111111.11100000`
                   `                              11111` => 31
Net mask decimal:  `255.255.255.224`
Broadcast address: `192.168.30.63`
IP range:          `33-62`
```

> 192.168.50.8/29

```bash
Network address:   `192.168.50.8`
Net mask binary:   `11111111.11111111.11111111.11111000`
                   `                                111` => 7
Net mask decimal:  `255.255.255.248`
Broadcast address: `192.168.50.15`
IP range:          `9-14`
```

> 3.3.3.2/28

```bash
Network address:   `3.3.3.2`
Net mask binary:   `11111111.11111111.11111111.11110000`
                   `                               1111` => 15
Net mask decimal:  `255.255.255.240`
Broadcast address: `3.3.3.17`
IP range:          `3-16`
```
