pipeline {
  agent any
  stages {
    stage('SonarQube Analysis') {
      steps {
        script {
          def scannerHome = tool 'SonarScanner for MSBuild'
              withSonarQubeEnv() {
                sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"mabocek_glitch-wars_AYyTjGI2uQ4UhGOB8co_\""
                sh "dotnet build"
                sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
              }
        }
      }
    }
    stage('Build') {
      steps {
        withDotNet(sdk: '8.0') {
          dotnetNuGetLocals()
          dotnetClean()
          dotnetToolRestore()
          dotnetRestore()
          dotnetBuild()
          dotnetTest()
        }
      }
    }
  }

    post {
      failure {
        script {
          def response = httpRequest(url: "http://${apiurl}/api/v1.0/CiCD/jenkins-failed-build", acceptType: 'TEXT_PLAIN', consoleLogResponseBody: true, contentType: 'APPLICATION_JSON', httpMode: 'POST', responseHandle: 'STRING', requestBody: "{ \"buildId\": \"${env.BUILD_ID}\", \"buildNumber\": \"${env.BUILD_NUMBER}\", \"buildTag\": \"${env.BUILD_TAG}\", \"buildUrl\": \"${env.BUILD_URL}\", \"executorNumber\": \"${env.EXECUTOR_NUMBER}\", \"javaHome\": \"${env.JAVA_HOME}\", \"jenkinsUrl\": \"${env.JENKINS_URL}\", \"jobName\": \"${env.JOB_NAME}\", \"nodeName\": \"${env.NODE_NAME}\", \"workspace\": \"${env.WORKSPACE}\" }")
          println("Status: "+response.status)
          println("Content: "+response.content)
        }
      }
    }
  
}
