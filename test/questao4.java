public class questao4 {
    public static void main(String[] args) {
        double sp = 67836.43;
        double rj = 36678.66;
        double mg = 29229.88;
        double es = 27165.48;
        double outros = 19849.53;
        double total = sp+rj+mg+es+outros;
        double percSp = (sp / total) * 100;
        double percRj = (rj / total) * 100;
        double percMg = (mg / total) * 100;
        double percEs = (es / total) * 100;
        double percOutros = (outros / total) * 100;


        System.out.printf("Percentual de São Paulo:  %.2f%%%n",percSp);
        System.out.printf("Percentual de Rio de janeiro:  %.2f%%%n",percRj);
        System.out.printf("Percentual de Minas Gerais:  %.2f%%%n",percMg);
        System.out.printf("Percentual de Espirito Santo:  %.2f%%%n",percEs);
        System.out.printf("Percentual dos outros estados:  %.2f%%%n",percOutros);
    }
}
