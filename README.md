# Güncel kuru takip eden ve değişim olması durumunda veri tabanını güncelleyen bir proje yapmaya çalıştım.

# Kullanılan teknolojiler ve programlama dilleri
- C#
- Dapper
- Thread
- Mssql
- Xml

# Açıklama: Döviz kurlarını takip edip çapraz kur hesabı ile veri tabanına her kurun birbirine göre değerini kaydeden bir proje yapmaya çalıştım. Thread mantığı ile xml kaynağına 5 dakikada bir istek attım ve değerlerin değişim durumuna göre çapraz kur değerleri yeniden hesaplanacak şekilde dizayn etmeye çalıştım. Sonuç olarak sürekli ayakta kalacak bir kur takip projesi ortaya çıkmış oldu.
