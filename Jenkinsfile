pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o publish'
            }
        }

        stage('Run App') {
            steps {
                bat '''
                cd publish
                start dotnet ProjectTestGit.dll
                '''
            }
        }
    }
}
