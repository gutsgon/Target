public class questao5 {
    public static void main(String[] args) {
        // A string pode ser definida diretamente no código
        String original = "Target Sistemas";
        String invertida = "";

        // Percorre a string de trás para frente
        for (int i = original.length() - 1; i >= 0; i--) {
            invertida += original.charAt(i); // Adiciona cada caractere na nova string
        }

        // Exibe o resultado
        System.out.println("String original: " + original);
        System.out.println("String invertida: " + invertida);
    }

}
