public class Main {
    public static void main(String[] args) {
        String stageEnviroment = System.getenv("ENV_STAGE");
        System.out.println("Hi! " + stageEnviroment + " is your stage! : )");
    }
}