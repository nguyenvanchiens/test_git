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
                bat "schtasks /delete /tn \"${params.PROJECT}\" /f 2>nul & exit /b 0"
                bat "schtasks /create /tn \"${params.PROJECT}\" /tr \"dotnet %WORKSPACE%\\publish\\${params.PROJECT}\\${params.PROJECT}.dll\" /sc once /st 00:00 /ru SYSTEM /f"
                bat "schtasks /run /tn \"${params.PROJECT}\""
            }
        }
    }
}
