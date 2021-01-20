pipeline {
    agent any      
    

    stages {        

            stage('Build') {
            steps 
            {
                echo 'dotnet build'
            }
        }
        stage('Test') {
            steps 
            {
                echo 'dotnet test --filter Name~"SwitchLanguage"'
            }
        }
    }
}