namespace Scarpe.Models
{
    public static class DB
    {
        private static int _maxId = 2;

        private static List<Articolo> _articoli = [
            new Articolo() { Id = 0, Name= "Jordan Air Jordan 1 Retro High OG", Description= "JLe Air Jordan 1 Retro High OG sono un'icona della cultura sneaker e del mondo dello streetwear. Questo modello ripropone fedelmente il design originale delle prime Air Jordan 1 del 1985, con una tomaia in pelle premium e la classica colorazione \"Chicago\", caratterizzata dai colori bianco, nero e rosso. La silhouette high-top offre supporto alla caviglia, mentre l'ammortizzazione Air-Sole nell'intersuola assicura comfort e reattività. Perfette per gli appassionati di sneaker alla ricerca di un'icona intramontabile.", Prezzo=160, ImgCover= "https://m.media-amazon.com/images/I/51W7CkgOPwL._AC_UY300_.jpg", ImgDetails=["https://m.media-amazon.com/images/I/51W7CkgOPwL._AC_UY300_.jpg", "https://assets.turbologo.com/blog/it/2019/12/19133052/air-jordan-logo-cover.png"] , Deleted=false},
            new Articolo() { Id = 1, Name = "Jordan Air Jordan", Description = " Le Jordan Air Jordan sono un'icona nel mondo delle sneaker, e la linea comprende diversi modelli, ciascuno con caratteristiche uniche.", Prezzo = 200, ImgCover = "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/24750e81-85ed-4b0e-8cd8-becf0cd97b2f/scarpa-air-jordan-1-mid-CR2SZ7.png", ImgDetails = ["https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/24750e81-85ed-4b0e-8cd8-becf0cd97b2f/scarpa-air-jordan-1-mid-CR2SZ7.png", "https://i.pinimg.com/originals/98/e5/a4/98e5a4811e32177795897d60231a016f.jpg"] , Deleted = false },
            new Articolo() { Id = 2, Name = "Jordan Air Jordan 11 Retro", Description = " Le Air Jordan 11 Retro sono celebri per il loro design iconico e l'elevato livello di comfort. Questo modello presenta una tomaia in pelle verniciata con dettagli in mesh traspirante per una ventilazione ottimale. La suola intermedia in schiuma Phylon e l'unità Air-Sole nel tallone offrono un'ammortizzazione leggera e reattiva. Il sistema di allacciatura con lacci tono su tono garantisce una calzata personalizzata. Le Jordan 11 sono un must-have per gli appassionati di sneaker e collezionisti.", Prezzo = 220, ImgCover = "https://dk.basketzone.net/zdjecia/2019/12/19/112/54/NIKE_AIR_JORDAN_11_RETRO_BRED-mini.jpg", ImgDetails =["https://dk.basketzone.net/zdjecia/2019/12/19/112/54/NIKE_AIR_JORDAN_11_RETRO_BRED-mini.jpg", "https://e0.pxfuel.com/wallpapers/300/215/desktop-wallpaper-jumpman-logo-group-air-jordan-logo.jpg"] , Deleted = false },
        ];

        public static List<Articolo> GetAll()
        {
            List<Articolo> articoli = [];
            foreach (var item in _articoli)
            {
                if(item.Deleted== false) articoli.Add(item);
            }
            return articoli;
        }

        public static List<Articolo> GetAllDeleted()
        {
            List<Articolo> articoliEliminati = [];
            foreach (var item in _articoli)
            {
                if (item.Deleted) articoliEliminati.Add(item);
            }
            return articoliEliminati;
        }

        public static Articolo? Recover(int IdToRecover)
        {
            int? index = findArticoloIndex(IdToRecover);
            if (index != null)
            {
                var articoloRimesso = _articoli[(int)index];
                articoloRimesso.Deleted = false;
                return articoloRimesso;
            }
            return null;
        }
        public static int? findArticoloIndex(int idToDelete)
        {
            int i;
            bool artFound = false;
            for (i = 0; i < _articoli.Count; i++)
            {
                if (_articoli[i].Id == idToDelete)
                {
                    artFound = true;
                    break;
                }
            }
            if (artFound) return i;
            return null;
        }

        public static Articolo? GetById(int? Id)
        {
            if(Id== null) return null;
            for(int i=0;  i < _articoli.Count; ++i)
            {
                Articolo art = _articoli[i];
                if(art.Id == Id) return art;
            }
            return null;
        }

        public static Articolo Add(Articolo articolo)
        {
            _maxId++;
            articolo.Id = _maxId;
            articolo.Deleted = false;
            _articoli.Add(articolo);
            return articolo;
        }

        public static Articolo? Edit(Articolo articolo)
        {
            int? index = findArticoloIndex(articolo.Id);
            if(index != null)
            {
                _articoli[(int)index].Name = articolo.Name;
                _articoli[(int)index].Prezzo = articolo.Prezzo;
                _articoli[(int)index].Description = articolo.Description;
                _articoli[(int)index].ImgCover = articolo.ImgCover;
                _articoli[(int)index].ImgDetails[0] = articolo.ImgDetails[0];
                _articoli[(int)index].ImgDetails[1] = articolo.ImgDetails[1];
                return _articoli[(int)index];
            }
            return null;
        }

        public static Articolo? softDelete(int idToDelete)
        {
            int? deletedI = findArticoloIndex(idToDelete);
            if (deletedI != null)
            {
                var artDeleted = _articoli[(int)deletedI];
                artDeleted.Deleted = true;
                return artDeleted;
            }
            return null;
        }

        public static Articolo? HardDeleted(int idToDelete)
        {
            int? deletedI = findArticoloIndex(idToDelete);
            if (deletedI != null)
            {
                var artDeleted = _articoli[(int)deletedI];
                _articoli.RemoveAt((int)deletedI);
                return artDeleted;
            }
            return null;
        }
    }
}
