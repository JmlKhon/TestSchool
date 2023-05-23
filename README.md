# TestSchool

## TestSchool project haqida:

Bu dastur, bizga jamoaviy ishlash muhitini ko'rsatish va oldin 
o'tilgan darslarni takrorlash uchun yordam beradi.

## Dastur nima qilishi haqida:
 
+ O'quvchi ro'yxatdan o'tishi va o'zgartirish mumkin
+ O'quvchilar turadigan manzillarni ro'yhatdan o'tkazish va o'zgartirish mumkin
+ Ro'yxatdan o'tkazilgan o'quvchi yoki manzilni o'chirish mumkin
+ Malumotlarni chiqarish mumkin

## Dasturni o'z kompyuteringizga sozlash:

1. Projectni Visual Studioda ochish kerak
2. appsettings.json ga kirish kerak
3. 1-qatordan `enter` orqali 2-qatorga tushib shu kodni yoziladi, agar bu code bo'lsa uning kerakli joylarini o'zgartirish lozim:
```.json
"ConnectionStrings": {
    "DefaultConnect": "user id=postgres; password=PgAdmin kodini kiriting; server=localhost; port=5432; database=Database nomini kiriting; pooling=true"
  },
```
4. Tools/NuGet Package Manager/Package Manager Consolega kiriladi
5. `add-database`  `o'zingi nom berasiz` kiritiladi (`enter`ni bosish esdan chiqmasin!)
6. `update-database` kiritiladi (`enter`ni bosish esdan chiqmasin!)
7. Dasturni `run` qilsangiz bo'ladi

Hello! I'm a student too. can you accept my changes? pull request request my homework.
