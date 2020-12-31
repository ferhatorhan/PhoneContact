# Telefon Rehberi
telefon rehber uygulması

#Migration Oluşturulması
 add-migration PhoneContact
 
#VeriTabanı değiştirilmesi
proje MsSql İle oluşturulmuştur. Eğer sizler isterseniz startup içersinden değişiklik yapabilirsiniz.

#Msql için
 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
 
#Postgresql için
 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));//
 
#Migration için
Add-Migration InitialCreate
