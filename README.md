# Termelő-fogyasztó probléma: Iroda
Írj konzolalkalmazást a termelő-fogyasztó probléma implementálására! Ügyelj a megfelelő lock-olásra és a termelők/fogyasztók leállítására!
## Nyomtatók az irodában
Egy irodában **3 adminisztrátor** dolgozik, akik dokumentumokat írnak és küldenek egy nyomtatási sorba.
Egy **dokumentumnak van terjedelme (oldalszám) és egy tulajdonosa (adminisztrátor sorszáma)**; a dokumentumot szervezd ki külön osztályba!
Az **első adminisztrátor 30 dokumentumot** ír, egyenként **5-10 oldal között** (random). A **második 25-öt**, **8-20 oldal** között. A **harmadik 20-at**, **12-25 között**. Ezeket rögtön a nyomtatási sorba küldik, amelynek a **max. mérete 20**.
Az irodában **4 printer működik**, melyek ugyanazt a közös nyomtatási sort használják. A nyomtató **kiveszi a legrégebbi dokumentumot** és kinyomtatja, amit azzal szimulálunk, hogy **oldalszám × 0.1 mp** ideig altatjuk.Addig nyomtatnak a nyomtatók, amíg van dokumentum a sorban. 
Bármilyen esemény történik, írasd ki a konzolra! Minden esetben írasd ki az érintett dokumentum adatait is!
 - *Zölddel*, ha új dokumentum kerül a sorba.
 - *Pirossal*, ha valamelyik nyomtató nyomtatja valamelyik dokumentumot.