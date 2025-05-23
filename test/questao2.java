import java.util.Scanner;
public class questao2 {
    // Função para calcular o número de Fibonacci
    public static int fibonacci(int n) {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return fibonacci(n - 1) + fibonacci(n - 2);
    }

    // Função para verificar se um número está na sequência de Fibonacci
    public static boolean isFibonacci(int num, int i) {
        int fib = fibonacci(i);
        if (fib == num) return true;
        if (fib > num) return false;
        return isFibonacci(num, i + 1);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Informe um número para verificar se pertence à sequência de Fibonacci: ");
        int number = scanner.nextInt();

        boolean pertence = isFibonacci(number, 0);

        if(!pertence) System.out.println("O número " + number + " NÃO pertence à sequência de Fibonacci.");
        if(pertence) System.out.println("O número " + number + " pertence à sequência de Fibonacci.");
        
        scanner.close();
    }
}
