# IF3210 Tubes Unity

### [TODO List](https://docs.google.com/document/d/1yY7RmJD9YZGf-wmjpBxvo6hABxueVf9PcHD9u6ccxvM/edit?usp=sharing) | [Ref:Notion](https://momentous-ring-807.notion.site/Agate-Survival-Shooter-b27ea3ef2545482bb10e2e0cda1bbc10)

### Deskripsi
Survival Shooter: Extended, merupakan game ekstensi Survival Shooter dari Unity Learn. Game dibangun dengan Unity 2021.2.16f1. Terdapat 2 mode ekstensi permainan yaitu Zen dan Wave.


### Cara Kerja, terutama mengenai pemenuhan spesifikasi aplikasi.

> -   Main menu  
>     Game ini memiliki main menu yang dimana player diberikan pilihan untuk mulai bermain **zen mode**/**wave mode**, melihat **scoreboard zen mode**, melihat **scoreboard wave mode**, dan **mengganti nama pemain**, serta diberikan juga **tombol exit** untuk keluar dari game dan **checkbox** untuk memilih mode **third person** atau **first person**.

> -   Scoreboard  
>     Terdapat 2 scoreboard, yaitu scoreboard untuk permain zen mode, dan scoreboard untuk wave mode. Pada scoreboard zen mode akan ditampilkan **nama pemain** dan **waktu survival (score)** pada mode tersebut. Sedangkan pada scoreboard wave mode akan ditampilkan **nama pemain**, **wave level**, dan **total score**. Kedua scoreboard ditampilkan dengan cara **terurut dari score terbaik**

> -   Game Over  
>     Setelah player sudah mati atau menang, maka akan muncul tampilan game over. Pada zen mode akan menampilkan waktu survival permainan. Sedangkan pada wave mode akan menampilkan wave level dan skor yang didapat. Selain itu terdapat juga **tombol replay** untuk mulai ulang permain dan **tombol main menu** untuk kembali ke main menu.

> -   Player Attribute  
>     Player memiliki 3 attribute yaitu **Power**, **Speed**, dan **Health**. Power akan mempengaruhi damage yang diberikan oleh senjata player ke musuh. Speed akan mempengaruhi kecepatan pergerakan player di map. Sedangkan health untuk darah atau nyawa yang tersisa dari player.
>     > -   **Power** : initial: 2; Max: 8
>     > -   **Speed** : Initial: 3; Max: 10
>     > -   **Health** : Initial: 300; Max: 10000

> -   New Mobs  
>     Pada game ini terdapat 3 monster tambahan yaitu **skeleton (mage)**, **bomber**, dan **boss**. Mage tidak bisa berjalan seperti monster lainnya, akan tetapi bisa menyerang dari jauh dengan melemparkan **projectile bola api**. Bomber memiliki darah atau health yang kecil, tapi untuk kecepatan dan damage yang diberikannya cukup besar. Sedangkan boss memiliki damage dan darah yang lebih besar.

> -   FPS Mode  
>     Game ini menyediakan fps mode / first person. Cara player bergerak dan menyerang musuh akan berbeda dengan mode yang biasanya.

> -   Zen Mode <br>
>     Zen mode merupakan mode game dimana monster akan di-summon secara terus menerus setiap 3 detik. Pada mode ini player yang dapat bertahan paling lama akan memiliki score yang paling besar juga karena scoring system yang dipakai adalah berdasarkan waktu bertahan yang paling lama.

> -   Wave Mode <br>
>     Wave mode merupakan mode game dengan 12 level dimana untuk memenangkannya, player harus membunuh semua monster pada setiap levelnya. Semakin tinggi levelnya, semakin banyak pula monster yang akan di-summon. Scoring system yang dipakai adalah score akan bertambah setiap ada monster yang mati (termasuk suicide attack).

> -   Orbs <br>
>     Terdapat 3 jenis orbs (speed, health dan power). Setiap orb akan dispawn di koordinat random dalam range map yang ditentukan. Waktu spawn diatur dengan coroutine setiap 10 detik.

> -   Weapon Upgrade<br>
>     Terdapat 2 opsi upgrade (diagonal dan speed). Kedua opsi diberikan dalam bentuk orb. 
Pada zen mode, Kedua opsi dispawn di sekitar titik pusat map setiap 25 detik. Hanya salah satu dari kedua opsi yang dapat diambil pada setiap 25 detiknya.
Pada wave mode, kedua opsi dispawn di sekitar titik pusat map setiap boss dikalahkan dan level telah dinaikkan.

### Library yang digunakan dan justifikasi penggunaannya.

> -   Semua Library yang digunakan merupakan bawaan dari UnityEngine seperti,
>     > -   UnityEngine.UI - Untuk mengatur UI pada canvas
>     > -   UnityEngine.SceneManagement - Untuk mengatur navigasi antar scene

### Screenshot aplikasi.

<div style="display:flex; flex-wrap: wrap; gap: 1%; justify-content:center">

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Intro (input player name)</h5>
<img src="Screenshot/intro.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Main Menu</h5>
<img src="Screenshot/menu.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Game Over Screen</h5>
<img src="Screenshot/game-over.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Zen Mode</h5>
<img src="Screenshot/zen.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Wave Mode</h5>
<img src="Screenshot/wave.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Zen Mode (FPS)</h5>
<img src="Screenshot/zen-fps.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Wave Mode (FPS)</h5>
<img src="Screenshot/wave-fps.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Scoreboard: Zen Mode</h5>
<img src="Screenshot/zen-scoreboard.png" />
</div>

<div style="width: 48%;">
<h5 style="margin-bottom:0;">Scoreboard: Wave Mode</h5>
<img src="Screenshot/wave-scoreboard.png" />
</div>

</div>

### Pembagian Tugas

-   Power Up System (Arvin)

    -   Orbs
    -   Weapon Upgrade

-   Game Mode (Karlsen)

    -   Save score
    -   Zen
    -   Wave

-   Game Manager (Yudi)
    -   Scoreboard & Main menu & Game Over
    -   Attribute Player
    -   Additional Mobs

### Anggota Kelompok

-   13519001 - Karlsen Adiyasa Bachtiar
-   13519051 - Yudi Alfayat
-   13519066 - Almeiza Arvin Muzaki
