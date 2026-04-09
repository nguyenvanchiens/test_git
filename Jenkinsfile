pipeline {
    agent any
    parameters {
        choice(
            name: 'PROJECT',
            choices: ['ProjectTestGit', 'ProjectA', 'ProjectB', 'ProjectC'],
            description: 'Chọn project cần build'
        )
    }
    stages {
        stage('Build') {
            steps {
                bat "dotnet build ${params.PROJECT}/${params.PROJECT}.csproj"
            }
        }
        stage('Publish') {
            steps {
                bat "dotnet publish ${params.PROJECT}/${params.PROJECT}.csproj -c Release -o publish\\${params.PROJECT}"
            }
        }
       stage('Run App') {
    steps {
        bat "taskkill /IM dotnet.exe /F 2>nul & exit /b 0"
        bat "powershell -Command \"Start-Process dotnet -ArgumentList '%WORKSPACE%\\publish\\${params.PROJECT}\\${params.PROJECT}.dll' -WorkingDirectory '%WORKSPACE%\\publish\\${params.PROJECT}' -RedirectStandardOutput '%WORKSPACE%\\app.log' -RedirectStandardError '%WORKSPACE%\\app-error.log' -NoNewWindow\""
    }
}
    }
}
